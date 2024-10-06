#include <string.h>
#include <unistd.h>
#include <stdlib.h>
#include <sys/types.h>
#include <sys/socket.h>
#include <netinet/in.h>
#include <stdio.h>
#include <mysql.h>

int main(int argc, char *argv[]) {
	
	int sock_conn, sock_listen, ret;
	struct sockaddr_in serv_adr;
	char peticion[512];
	char respuesta[512];
	// INICIALITZACIONS
	// Obrim el socket
	if ((sock_listen = socket(AF_INET, SOCK_STREAM, 0)) < 0)
		printf("Error creant socket");
	// Fem el bind al port
	
	
	memset(&serv_adr, 0, sizeof(serv_adr));// inicialitza a zero serv_addr
	serv_adr.sin_family = AF_INET;
	
	// asocia el socket a cualquiera de las IP de la m?quina. 
	//htonl formatea el numero que recibe al formato necesario
	serv_adr.sin_addr.s_addr = htonl(INADDR_ANY);
	// establecemos el puerto de escucha
	serv_adr.sin_port = htons(9005);
	if (bind(sock_listen, (struct sockaddr *) &serv_adr, sizeof(serv_adr)) < 0)
		printf ("Error al bind");
	
	if (listen(sock_listen, 3) < 0)
		printf("Error en el Listen");
	
	MYSQL *conn;
	int err;
	// Estructura especial para almacenar resultados de consultas
	MYSQL_RES *resultado;
	MYSQL_ROW row;
	//Creamos una conexion al servidor MYSQL
	
	
	int i;
	// Bucle infinito
	for (;;)
	{
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
		
		sock_conn = accept(sock_listen, NULL, NULL);
		printf ("He recibido conexion\n");
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
			if(codigo != 0)
			{
				p = strtok(NULL,"/");
				strcpy(consulta,p);
			}
			if (codigo == 0)
			{
			  terminar = 1;	
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
			if (codigo !=0)
			{
				
				printf ("Respuesta: %s\n", respuesta);
				// Enviamos respuesta
				write (sock_conn,respuesta, strlen(respuesta));
			}
			
			
		}
		//Cerrar conexion con la base de datos 
		mysql_close (conn);
		// Se acabo el servicio para este cliente
		close(sock_conn); 
	}
	return 0;
}

