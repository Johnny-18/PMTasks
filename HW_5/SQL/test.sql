call insert_user('Dmitro', 'Demyanov');
call insert_user('Andrey', 'Andreeev');
call insert_user('Ivan', 'Zherybor');
call insert_user('Michael', 'Voznyuk');

call insert_note('caa798d3-14b4-4836-8dcf-026602676232', 'Title 1', 'Body 1', 1);
call insert_note('caa798d3-14b4-4836-8dcf-026602676132', 'Exam', 'Math 94A', 1);
call insert_note('caa798d3-14b4-4836-8dcf-126602676132', 'Exam2', 'OOP 92A', 1);
call insert_note('caa798d3-14b4-4836-8dcf-226602676132', 'Exam3', 'NA 91A', 1);
call insert_note('caa798d3-14b4-4836-8dcf-026602676233', 'Title 2', 'Body 2', 2);
call insert_note('caa798d3-14b4-4836-8dcf-026602676234', 'Title 3', 'Body 3', 2);
call insert_note('caa798d3-14b4-4836-8dcf-026602676235', 'Title 4', 'Body 4', 3);
call insert_note('caa798d3-14b4-4836-8dcf-026602676236', 'Title 5', 'Body 5', 3);
call insert_note('caa798d3-14b4-4836-8dcf-026602676237', 'Title 6', 'Body 6', 4);
call insert_note('caa798d3-14b4-4836-8dcf-026602676238', 'Title 7', 'Body 7', 4);
call insert_note('caa798d3-14b4-4836-8dcf-026602676239', 'Title 8', 'Body 8', 4);

select * from select_note('caa798d3-14b4-4836-8dcf-026602676232');
select * from select_note('caa798d3-14b4-4836-8dcf-026602676233');
select * from select_note('caa798d3-14b4-4836-8dcf-026602676234');

call update_note_mark_deleted('caa798d3-14b4-4836-8dcf-026602676233');
call update_note_mark_deleted('caa798d3-14b4-4836-8dcf-026602676239');
call update_note_mark_deleted('caa798d3-14b4-4836-8dcf-026602676238');
call update_note_mark_deleted('caa798d3-14b4-4836-8dcf-126602676132');

select * from select_user_notes(1);
select * from select_user_notes(2);
select * from select_user_notes(3);
select * from select_user_notes(4);

select * from select_users_notes_count();