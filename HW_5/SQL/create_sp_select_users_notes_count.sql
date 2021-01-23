create or replace function select_users_notes_count()
returns table(id int,
              first_name varchar(128),
              last_name varchar(128),
              count_notes bigint)
    language sql
as $$
    select u.id, u.first_name, u.last_name, count(n.id)
    from users u
    inner join notes n
    on n.user_id = u.id and n.is_deleted = false
    group by u.id, u.first_name, u.last_name
    $$;