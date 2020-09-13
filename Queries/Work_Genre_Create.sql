CREATE TABLE work_genre (
  work_id    int REFERENCES works (id) ON UPDATE CASCADE ON DELETE CASCADE
, genre_id int REFERENCES genres (id) ON UPDATE CASCADE
, CONSTRAINT work_genre_pkey PRIMARY KEY (work_id, genre_id)  -- explicit pk
);