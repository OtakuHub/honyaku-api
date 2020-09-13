create table token(
	id serial primary key,
	user_id int references users (id) On delete set null on update cascade,
	create_at timestamp not null,
	update_at timestamp not null,
	value varchar(50) not null,
	ip_address varchar(20),
	user_agent varchar (50)
)