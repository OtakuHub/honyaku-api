create table User (
	user_id serial PRIMARY KEY,
	username varchar(60) UNIQUE NOT NULL,
	password varchar (50) NOT NULL,
	confirm_password varchar (50) NOT NULL,
	email varchar (120) UNIQUE NOT NULL,
	creation_date timestamp,
	profile_picture bytea,
	picture_name text,
	is_translator boolean NOT NULL
)