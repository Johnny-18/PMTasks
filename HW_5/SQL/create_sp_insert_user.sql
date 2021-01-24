create or replace procedure insert_user(name varchar(128), surname varchar(128))
    language sql
as $$
    insert into users(first_name, last_name) values(name, surname)
    $$;

