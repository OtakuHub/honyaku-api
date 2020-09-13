alter table users rename column user_id to id;
alter table users rename column creation_date to created_at;
alter table works rename column work_id to id;
alter table genres rename column genre_id to id;
alter table comments rename column comment_id to id;
alter table comments rename column for_title to work;
alter table users alter column profile_picture type varchar (500);
alter table users drop column picture_name;
alter table users add column updated_at timestamp;
alter table works add column picture varchar (500);
alter table comments add column created_at timestamp;
alter table comments add column updated_at timestamp;
alter table genres drop column work_title;

