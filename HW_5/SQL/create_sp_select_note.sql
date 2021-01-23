create or replace function select_note(note_id uuid)
    returns table(id uuid,
                  header varchar(128),
                  body varchar(1024),
                  is_deleted boolean,
                  user_id int,
                  modified_at timestamp with time zone,
                  first_name varchar(128),
                  last_name varchar(128))
    language sql
as $$
    select n.id, n.header, n.body, n.is_deleted, n.user_id, n.modified_at, u.last_name, u.first_name
    from notes n
    inner join users u
    on n.user_id = u.id
    where n.id = note_id;
    $$;