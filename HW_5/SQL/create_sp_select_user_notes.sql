create or replace function select_user_notes(id_ int)
returns table(id uuid,
              header varchar(128),
              body varchar(1024),
              is_deleted boolean,
              user_id int,
              modified_at timestamp with time zone)
    language sql
as $$
    select distinct n.*
    from users u
    inner join notes n
    on n.user_id = id_ and n.is_deleted = false
    $$;