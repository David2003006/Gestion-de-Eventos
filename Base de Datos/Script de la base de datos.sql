create database eventos;

use eventos;

create table eventos( 
id_evento int auto_increment primary key,
nombre varchar(50),
descripcion varchar(50),
fecha date ,
hora time(0),
direccion varchar(50),
capacidad_max int,
costo double
);

create table usuarios(
id_usuario int auto_increment primary key,
nombre varchar(50),
apellido varchar(50),
fecha_nacimiento date,
nombre_usuario varchar(50),
metodo_de_pago varchar(50),
unique(id_usuario)
);

create table organizadores(
id_organizador int auto_increment not null primary key,
nombre varchar(50),
apellido varchar(50),
fecha_nacimiento date,
nombre_usuario varchar(50),
unique(id_organizador)
);

create table inicio_de_secion(
id_inicioSecion int auto_increment not null primary key,
usuario_id int default null,
organizador_id int default null,
correo varchar(50),
contrasena varchar(10),
activo bool default true,
foreign key (usuario_id) references usuarios(id_usuario),
foreign key (organizador_id) references organizadores(id_organizador),
unique(correo)
);

create table eventos_favoritos(
id_favorito int auto_increment not null primary key,
id_usuario int,
id_evento int,
foreign key (id_usuario) references usuarios (id_usuario),
foreign key (id_evento) references eventos (id_evento),
unique(id_usuario, id_evento)
);

create table seguir_organizadores(
id_seguidor int auto_increment not null primary key,
id_usuario int,
id_organizador int,
foreign key (id_usuario) references usuarios(id_usuario),
foreign key (id_organizador) references organizadores(id_organizador),
unique(id_usuario, id_organizador)
); 

create table pregunta(
id_pregunta int auto_increment not null primary key,
id_usuario int not null,
id_organizador int not null,
pregunta varchar(50),
foreign key (id_usuario) references usuarios (id_usuario),
foreign key (id_organizador) references organizadores (id_organizador),
unique(id_usuario, id_organizador)
);

create table comentarios(
id_comentario int auto_increment not null primary key,
id_usuario int not null,
id_organizador int not null,
comentario varchar(50),
foreign key (id_usuario) references usuarios (id_usuario),
foreign key (id_organizador) references organizadores (id_organizador),
unique(id_usuario, id_organizador)
);

create table asistencias(
id_asistencia int auto_increment not null primary key,
id_usuario int, 
id_evento int,
foreign key (id_usuario) references usuarios (id_usuario),
foreign key (id_evento) references eventos (id_evento),
unique(id_asistencia, id_usuario, id_evento)
);

create table historial_usurario(
id_usuario int not null,
id_evento int not null,
id_asistencia int not null,
foreign key (id_usuario) references usuarios (id_usuario),
foreign key (id_evento) references eventos (id_evento),
foreign key (id_asistencia) references asistencias (id_asistencia),
unique(id_usuario, id_evento)
);

