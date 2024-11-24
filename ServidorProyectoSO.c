#include <string.h>
#include <unistd.h>
#include <stdlib.h>
#include <sys/types.h>
#include <sys/socket.h>
#include <netinet/in.h>
#include <stdio.h>
#include <pthread.h>
#include <mysql.h>


int sockets[100];
int i=0;


typedef struct 
{
	char nombre[200];
	int clase;
	int socket;
} Conectado;

typedef struct
{
   Conectado conectados[100];
   int num;
} ListaConectados;

typedef struct
{
	Conectado jugador1;
	Conectado jugador2;
	
}Partida;

int Pon(ListaConectados *lista, char nombre[20], int clase, int socket)
{
	if (lista->num == 100)
	{
		return -1;
	}
	else
	{
		strcpy(lista->conectados[lista->num].nombre,nombre);
		lista->conectados[lista->num].clase = clase;
		lista->conectados[lista->num].socket = socket;
		printf("AÃ±adido cliente %s con clase %d en el socket %d, posiciÃ³n %d en la lista\n", 
			   nombre, clase, socket, lista->num);
		lista->num++;
		return 0;
}
}

int DameSocket(ListaConectados *lista, char nombre[20]) {
	for (int i = 0; i < lista->num; i++) {
		if (strcmp(lista->conectados[i].nombre, nombre) == 0) {
			return lista->conectados[i].socket;
		}
	}
	return -1; // No encontrado
}
	
int DamePosicion(ListaConectados *lista, char nombre[20])
	{
		int i = 0;
		int encontrado = 0;
		while ((i < lista->num) && !encontrado)
		{
		  if(strcmp(lista->conectados[i].nombre,nombre) == 0)
		  {
			encontrado = 1;
		  }
		  if(!encontrado)
		  {
			i = i + 1;  
		  }
		}
		
		if(encontrado)
		{
		  return i;	
		}
		else
		{
		 return -1;	
		}
	}
int AnadirJugador1APartida(Partida *partida, ListaConectados *lista, char nombre[20]) 
{
		int pos = DamePosicion(lista, nombre);
		if (pos == -1) {
			// No se encontrÃ³ el jugador en la lista
			return -1;
		}
		
		// Copiar los datos al jugador 1
		partida->jugador1 = lista->conectados[pos];
		printf("Jugador %s aÃ±adido como Jugador 1 en la partida.\n", nombre);
		
		return 0; // 
	}
	
int AnadirJugador2APartida(Partida *partida, ListaConectados *lista, char nombre[20]) 
{
		int pos = DamePosicion(lista, nombre);
		if (pos == -1) {
			// No se encontrÃ³ el jugador en la lista
			return -1;
		}
		
		// Copiar los datos al jugador 2
		partida->jugador2 = lista->conectados[pos];
		printf("Jugador %s aÃ±adido como Jugador 2 en la partida.\n", nombre);
		
		return 0; // Ãxito
	}
	
	
int Elimina(ListaConectados *lista, char nombre[20])
{
	int pos = DamePosicion(lista, nombre);
	if (pos == -1)
	{
		return -1;  // No se encontrÃ³ el cliente en la lista
	}
	else
	{
		printf("Eliminando cliente %s en la posiciÃ³n %d\n", nombre, pos);
		
		for (int i = pos; i < lista->num - 1; i++)
		{
			strcpy(lista->conectados[i].nombre, lista->conectados[i + 1].nombre);
			lista->conectados[i].clase = lista->conectados[i + 1].clase;
			lista->conectados[i].socket = lista->conectados[i + 1].socket;
			sockets[i] = sockets[i + 1];  // Sincroniza el array `sockets` si es necesario
		}
		
		lista->num--;  // Reduce el nÃºmero de elementos en `miLista`
		printf("Cliente eliminado. Total de conectados: %d\n", lista->num);
		
		return 0;  // EliminaciÃ³n exitosa
	}
}

void DameConectados(ListaConectados *lista, char conectados[300])
{
  sprintf(conectados,"%d",lista->num);
  int i;
  for(i = 0; i < lista->num; i++)
  {
	sprintf(conectados, "%s/%s",conectados,lista->conectados[i].nombre);
  }
}



Partida partida;
ListaConectados miLista;
ListaConectados miLista = { .num = 0 };
pthread_mutex_t mutex = PTHREAD_MUTEX_INITIALIZER;

void EnviarListaConectadosATodos()
{
	char conectados[300];
	sprintf(conectados, "7/");  // Empieza el mensaje con "7/" para que el cliente identifique este mensaje
	
	char lista[250];
	DameConectados(&miLista, lista);  // Obtener la lista de conectados
	strcat(conectados, lista);  // Concatenar la lista de conectados al mensaje
	
	printf("Mensaje de lista de conectados a enviar: %s\n", conectados); 
	// Enviar a todos los clientes conectados
	for (int i = 0; i < miLista.num; i++)
	{
		printf("Enviando lista actualizada al cliente en el socket %d\n", miLista.conectados[i].socket);
		write(sockets[i], conectados, strlen(conectados));
	}
}

void *AtenderCliente (void *socket)
{
	
	int sock_conn;
	int *s;
	s= (int *) socket;
	sock_conn= *s;
	char nombre[20];
	//int socket_conn = * (int *) socket;
	
	char peticion[512];
	char respuesta[512];
	int ret;
	
	MYSQL *conn;
	int err;
	// Estructura especial para almacenar resultados de consultas
	MYSQL_RES *resultado;
	MYSQL_ROW row;
	
	conn = mysql_init(NULL);
	if (conn==NULL) {
		printf ("Error al crear la conexi\uffc3\uffb3n: %u %s\n",
				mysql_errno(conn), mysql_error(conn));
		exit (1);
	}
	//inicializar la conexion
	conn = mysql_real_connect (conn, "shiva2.upc.es","root", "mysql", "M2_BBDDJuego", 0, NULL, 0); 
	if (conn==NULL) {
		printf ("Error al inicializar la conexi\uffc3\uffb3n: %u %s\n",
				mysql_errno(conn), mysql_error(conn));
		exit (1);
	}
	
	printf ("Escuchando\n");
	
	//sock_conn es el socket que usaremos para este cliente
	
	int terminar =0;
	// Entramos en un bucle para atender todas las peticiones de este cliente
	//hasta que se desconecte
	while (terminar ==0)
	{
		// Ahora recibimos la petici?n
		ret=read(sock_conn,peticion, sizeof(peticion));
		printf ("Recibido\n");
		
		// Tenemos que a?adirle la marca de fin de string 
		// para que no escriba lo que hay despues en el buffer
		peticion[ret]='\0';
		
		
		printf ("Peticion: %s\n",peticion);
		
		char *p = strtok(peticion,"/");
		int codigo = atoi(p);
		char consulta[200];
		if(codigo != 0 && codigo != 6)
		{
			p = strtok(NULL,"/");
			strcpy(consulta,p);
		}
		if (codigo == 0)
		{
			terminar = 1;
			pthread_mutex_lock(&mutex);
			
			int resultado = Elimina(&miLista, nombre);  // Guardamos el resultado de la eliminaciÃ³n
			if (resultado == 0) {
				printf("Cliente %s eliminado correctamente en el socket %d\n", nombre,sock_conn);
				// Notificar a los demÃ¡s clientes que este cliente se ha desconectado
				EnviarListaConectadosATodos();
			} else {
				printf("Error: No se encontrÃ³ el cliente %s en la lista de conectados\n", nombre);
			}
			
			pthread_mutex_unlock(&mutex);
		}
		
		if (codigo == 1)
		{
			err = mysql_query(conn,consulta);
			if (err != 0)
			{
				printf ("Error al introducir datos la base %u %s\n", mysql_errno(conn), mysql_error(conn)); 
				exit(1);
			}
			else
			{
				sprintf (respuesta,"1/Se han introducido los datos correctamente");	
			}
		}
		if (codigo == 2)
		{
			printf("%s",consulta);
			char resp[200] = "";
			err = mysql_query(conn,consulta);
			if (err != 0)
			{
				printf ("Error al introducir datos la base %u %s\n", mysql_errno(conn), mysql_error(conn)); 
				exit(1);
			}
			resultado = mysql_store_result (conn); 
			row = mysql_fetch_row (resultado); 
			
			if (row == NULL)
			{
				printf("No se han obtenido datos de la consulta\n");	
			}
			else 
			{
				sprintf(resp,"2");
				while(row != NULL)
				{
					sprintf(resp,"%s/%s",resp,row[0]);
					row = mysql_fetch_row (resultado); 
				}
			}
			strcpy(respuesta,resp);
			mysql_free_result(resultado);
			
			
		}
		if(codigo == 3)
		{
			printf("%s",consulta);
			char resp[200] = "";
			err = mysql_query(conn,consulta);
			if (err != 0)
			{
				printf ("Error al introducir datos la base %u %s\n", mysql_errno(conn), mysql_error(conn)); 
				exit(1);
			}
			resultado = mysql_store_result (conn); 
			row = mysql_fetch_row (resultado); 
			
			if (row == NULL)
			{
				printf("No se han obtenido datos de la consulta\n");	
			}
			else 
			{
				sprintf(resp,"3");
				while(row != NULL)
				{
					sprintf(resp,"%s/%s",resp,row[0]);
					row = mysql_fetch_row (resultado); 
				}
			}
			strcpy(respuesta,resp);
			mysql_free_result(resultado);
			
		}
		if (codigo == 4)
		{
			printf("%s",consulta);
			char resp[200] = "";
			err = mysql_query(conn,consulta);
			if (err != 0)
			{
				printf ("Error al introducir datos la base %u %s\n", mysql_errno(conn), mysql_error(conn)); 
				exit(1);
			}
			resultado = mysql_store_result (conn); 
			row = mysql_fetch_row (resultado); 
			
			if (row == NULL)
			{
				printf("No se han obtenido datos de la consulta\n");	
			}
			else 
			{   
				sprintf(resp,"4/");
				while(row != NULL)
				{
					sprintf(resp,"%s%s",resp,row[0]);
					row = mysql_fetch_row (resultado); 
				}
			}
			strcpy(respuesta,resp);
			printf("%s",respuesta);
			mysql_free_result(resultado);
			
		}
		if (codigo == 5)
		{
			pthread_mutex_lock(&mutex);
			
			// Parseamos los datos de la peticiÃ³n
			p = strtok(NULL, "/");
			int clase = atoi(p);
			strcpy(nombre, consulta);
			
			// AÃ±adimos el nuevo cliente a la lista de conectados
			int err = Pon(&miLista, consulta, clase, sock_conn);
			char conectados[300];
			DameConectados(&miLista,conectados);
			if (err == -1)
			{
				sprintf(respuesta, "5/No se ha podido conectar al servidor");
			}
			else
			{
				sprintf(respuesta, "5/%s",conectados);
				
				// Notificar a todos los clientes conectados que se ha conectado un cliente
				char notificacion[100];
				sprintf(notificacion, "5/%s", conectados);
				
				for (int j = 0; j < miLista.num; j++)
				{
					if (miLista.conectados[j].socket != sock_conn) // Evita enviar la notificaciÃ³n al propio cliente
					{
						printf("Añadiendo lista cliente en el socket %d\n", miLista.conectados[i].socket);
						write(miLista.conectados[j].socket, notificacion, strlen(notificacion));
					}
				}
				
				// Insertar en la base de datos
				char query[200];
				sprintf(query, "INSERT INTO players (name, class) VALUES ('%s', %d);", consulta, clase);
				printf("%s\n", query);
				
				err = mysql_query(conn, query);
				if (err != 0)
				{
					printf("Error al introducir datos en la base %u %s\n", mysql_errno(conn), mysql_error(conn));
					exit(1);
				}
				else
				{
					printf("Se han introducido los datos correctamente en la base de datos\n");
				}
			}
			
			pthread_mutex_unlock(&mutex);
		}
		if (codigo == 10) 
		{
			pthread_mutex_lock(&mutex);
			
			char nombreInvitador[20];
			char nombreInvitado[20];
			
			// Obtenemos los nombres del invitador e invitado
			strcpy(nombreInvitador, consulta);
			strcpy(nombreInvitado, strtok(NULL, "/"));
			
			// Obtenemos los sockets de ambos usuarios
			int socketInvitado = DameSocket(&miLista, nombreInvitado);
			int socketInvitador = DameSocket(&miLista, nombreInvitador);
			
			// AÃ±adir el jugador que invita como Jugador 1
			if (AnadirJugador1APartida(&partida, &miLista, nombreInvitador) == -1) {
				printf("Error: No se pudo aÃ±adir al jugador %s como jugador 1.\n", nombreInvitador);
			}
			
			if (socketInvitado != -1) 
			{
				char invitacion[100];
				sprintf(invitacion, "10/%s", nombreInvitador);
				printf("%s",invitacion);
				write(socketInvitado, invitacion, strlen(invitacion));
			} 
			else 
			{
				char msg[100];
				sprintf(msg, "12/El usuario %s no esta conectado.", nombreInvitado);
				write(socketInvitador, msg, strlen(msg));
			}
			
			pthread_mutex_unlock(&mutex);
		}
		
		if (codigo == 11) 
		{
			pthread_mutex_lock(&mutex);
			
			char nombreInvitador[20];
			char nombreInvitado[20];
			char respuesta[20];
			
			// Recuperamos los datos directamente del mensaje recibido
			strcpy(nombreInvitador, consulta);
			strcpy(nombreInvitado, strtok(NULL, "/"));
			strcpy(respuesta, strtok(NULL, "/"));  // "aceptado" o "rechazado"
			
			if (strcmp(respuesta, "aceptado") == 0) {
				// AÃ±adir el jugador invitado como Jugador 2
				if (AnadirJugador2APartida(&partida, &miLista, nombreInvitado) == -1) {
					printf("Error: No se pudo aÃ±adir al jugador %s como jugador 2.\n", nombreInvitado);
				} else {
					printf("Partida iniciada entre %s (Jugador 1) y %s (Jugador 2).\n",
						   partida.jugador1.nombre, partida.jugador2.nombre);
				}
			}
			
			int socketInvitador = DameSocket(&miLista, nombreInvitador);
			int socketInvitado = DameSocket(&miLista, nombreInvitado);
			
			if (socketInvitador != -1 && socketInvitado != -1) 
			{
				char msg[100];
				if (strcmp(respuesta, "aceptado") == 0) 
				{
					sprintf(msg, "12/El usuario %s ha aceptado la invitacion.¡Comienza la partida!", nombreInvitado);
				} 
				else 
				{
					sprintf(msg, "12/El usuario %s ha rechazado la invitacion. No se jugara la partida.", nombreInvitado);
				}
				
				// Enviar mensaje al invitador
				write(socketInvitador, msg, strlen(msg));
				
				// Enviar mensaje al invitado
				write(socketInvitado, msg, strlen(msg));
			} 
			else 
			{
				// Si alguno no estÃ¡ conectado, notificamos al invitador que no se puede realizar la invitaciÃ³n
				char msg[100];
				sprintf(msg, "12/El usuario %s no esta conectado. No se puede enviar la invitacion.", nombreInvitado);
				write(socketInvitador, msg, strlen(msg));
			}
			
			pthread_mutex_unlock(&mutex);
		}
		if (codigo == 20) {
			pthread_mutex_lock(&mutex);
			
			// Parsear los datos del mensaje
			char nombreRemitente[20];
			char mensaje[256];
			strcpy(nombreRemitente, consulta); // Nombre del jugador que envÃ­a el mensaje
			strcpy(mensaje, strtok(NULL, "/")); // Mensaje enviado
			
			// Crear el mensaje para enviar
			char mensajeParaEnviar[300];
			sprintf(mensajeParaEnviar, "20/%s/%s", nombreRemitente, mensaje);
			
			// Enviar el mensaje a ambos jugadores de la partida
			if (write(partida.jugador1.socket, mensajeParaEnviar, strlen(mensajeParaEnviar)) == -1) {
				perror("Error al enviar mensaje al Jugador 1");
			}
			if (write(partida.jugador2.socket, mensajeParaEnviar, strlen(mensajeParaEnviar)) == -1) {
				perror("Error al enviar mensaje al Jugador 2");
			}
			
			pthread_mutex_unlock(&mutex);
		}
		
		
		
		if (codigo != 0 && codigo != 10 && codigo != 11)
		{
			
			printf ("Respuesta: %s\n", respuesta);
			// Enviamos respuesta
			write (sock_conn,respuesta, strlen(respuesta));
		}
		
		// vamos a ver que quieren
		
	}
	//Cerrar conexion con la base de datos 
	mysql_close (conn);
	// Se acabo el servicio para este cliente
	close(sock_conn); 
	
	
}

int main(int argc, char *argv[])
{
	int sock_conn, sock_listen, ret;
	struct sockaddr_in serv_adr;
	char peticion[512];
	char respuesta[512];
	// INICIALITZACIONS
	// Obrim el socket
	if ((sock_listen = socket(AF_INET, SOCK_STREAM, 0)) < 0)
		printf("Error creant socket");
	// Fem el bind al port
	ListaConectados miLista;
	miLista.num = 0;
	
	
	memset(&serv_adr, 0, sizeof(serv_adr));// inicialitza a zero serv_addr
	serv_adr.sin_family = AF_INET;
	
	// asocia el socket a cualquiera de las IP de la m?quina. 
	//htonl formatea el numero que recibe al formato necesario-Wall -pedantic-errors -O0 -o programa programa.c -lmysqlclient -pthread
	serv_adr.sin_addr.s_addr = htonl(INADDR_ANY);
	// establecemos el puerto de escucha
	serv_adr.sin_port = htons(50005);
	if (bind(sock_listen, (struct sockaddr *) &serv_adr, sizeof(serv_adr)) < 0)
		printf ("Error al bind");
	
	if (listen(sock_listen, 3) < 0)
		printf("Error en el Listen");
	
	
	//Creamos una conexion al servidor MYSQL
	
	
	pthread_t thread;
	
	// Bucle para atender a 5 clientes
	for (;;)
	{
		printf ("Escuchando\n");
		
		sock_conn = accept(sock_listen, NULL, NULL);
		printf ("He recibido conexion\n");
		
		sockets[i] =sock_conn;
		//sock_conn es el socket que usaremos para este cliente
		
		// Crear thead y decirle lo que tiene que hacer
		
		pthread_create (&thread, NULL, AtenderCliente,&sockets[i]);
		i++;
	}
		
	
	
	return 0;
}