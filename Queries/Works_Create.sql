create table works (
	work_id serial PRIMARY KEY,
	category varchar (10) NOT NULL,
	title varchar (255) NOT NULL,
	description text,
	translators int,
	FOREIGN KEY (translators)
		REFERENCES users (user_id)
)