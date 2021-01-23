create table notes(
    id uuid primary key,
    header varchar(128) not null,
    body varchar(1024) not null,
    is_deleted boolean not null,
    user_id int not null,
    modified_at timestamp with time zone not null default current_timestamp,
    constraint fk_user_id foreign key (user_id) references users(id)
);

create index if not exists modified_idx on notes (modified_at);