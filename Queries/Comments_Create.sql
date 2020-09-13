create table comments (
	comment_id serial PRIMARY KEY,
	for_title int NOT NULL,
	author int NOT NULL,
	comment text,
	FOREIGN KEY (for_title)
		REFERENCES works (work_id),
	FOREIGN KEY (author)
		REFERENCES users (user_id)
)