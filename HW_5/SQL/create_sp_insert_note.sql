create or replace procedure insert_note(id uuid, header varchar(128), body varchar(1024), user_id int)
    language sql
as $$
    insert into notes values (id, header, body, false, user_id)
    $$;

