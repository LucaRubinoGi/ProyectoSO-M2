#include <string.h>
#include <unistd.h>
#include <stdlib.h>
#include <sys/types.h>
#include <sys/socket.h>
#include <netinet/in.h>
#include <stdio.h>
#include <pthread.h>
#include <mysql.h>



typedef struct 
{
	char nombre[200];
	int clase;
} Conectado;

typedef struct
{
   Conectado conectados[100];
   int num;
} ListaConectados;

int Pon(ListaConectados *lista, char nombre[20], int clase)
{
	if (lista->num == 100)
	{
		return -1;
	}
	else
	{
		strcpy(lista->conectados[lista->num].nombre,nombre);
		lista->conectados[lista->num].clase = clase;
		lista->num++;
		return 0;
}
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
	
int Elimina(ListaConectados *lista, char nombre[20])
{
	int pos = DamePosicion(lista, nombre);
	if (pos == -1)
	{
	  return -1;	
	}
	else
	{
	 int i;
	 for (i = pos; i < lista->num-1; i++)
	 {
		//lista->conectados[i] = lista->conectados[i+1];
		strcpy(lista->conectados[i].nombre, lista->conectados[i+1].nombre);
		lista->conectados[i].clase = lista->conectados[i+1].clase;
	 }
	}
	lista->num--;
	return 0;
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

ListaConectados miLista;
ListaConectados miLista = { .num = 0 };
pthread_mutex_t mutex = PTHREAD_MUTEX_INITIALIZER;

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
	conn = mysql_real_connect (conn, "localhost","root", "mysql", "proyecto", 0, NULL, 0); 
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
			Elimina(&miLista,nombre);
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
				sprintf (respuesta,"Se han introducido los datos correctamente");	
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
				while(row != NULL)
				{
					sprintf(resp,"%s",row[0]);
					row = mysql_fetch_row (resultado); 
				}
			}
			strcpy(respuesta,resp);
			mysql_free_result(resultado);
			
		}
		if (codigo == 5)
		{
		 pthread_mutex_lock(&mutex);
		 p = strtok(NULL,"/");
		 int clase = atoi(p);
		 strcpy(nombre, consulta);
		 int err = Pon(&miLista, consulta, clase);
		 
		 char query[200];
		 sprintf(query,"INSERT INTO players (name, class) VALUES ('%s', %d);",consulta,clase);
		 printf("%s\n",query);
		 err = mysql_query(conn,query);
		 if (err != 0)
		 {
			 printf ("Error al introducir datos la base %u %s\n", mysql_errno(conn), mysql_error(conn)); 
			 exit(1);
		 }
		 else
		 {
			 sprintf (respuesta,"Se han introducido los datos correctamente");	
		 }
		 
		 if (err == -1)
		 {
		   strcpy(respuesta,"No se ha podido conectar al servidor");
		 }
		 else
		 {
			 strcpy(respuesta,"Jugador conectado");
		 }
		 pthread_mutex_unlock(&mutex);
		 
		}
		if (codigo == 6)
		{
		 printf("Hola");
		 char conectados[300];
		 pthread_mutex_lock(&mutex);
		 DameConectados(&miLista, conectados);
		 strcpy(respuesta, conectados);
		 pthread_mutex_unlock(&mutex);
		 
		}
		if (codigo !=0)
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
	//htonl formatea el numero que recibe al formato necesario
	serv_adr.sin_addr.s_addr = htonl(INADDR_ANY);
	// establecemos el puerto de escucha
	serv_adr.sin_port = htons(9030);
	if (bind(sock_listen, (struct sockaddr *) &serv_adr, sizeof(serv_adr)) < 0)
		printf ("Error al bind");
	
	if (listen(sock_listen, 3) < 0)
		printf("Error en el Listen");
	
	
	//Creamos una conexion al servidor MYSQL
	
	int sockets[100];
	pthread_t thread;
	int i=0;
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
	}
		
	
	
	return 0;
}
