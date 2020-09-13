create table genres (
	genre_id serial PRIMARY KEY,
	work_title int NOT NULL,
	genre varchar (50),
	FOREIGN KEY (work_title)
		REFERENCES works (work_id)
)