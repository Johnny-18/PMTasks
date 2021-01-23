create or replace procedure update_note_mark_deleted(note_id uuid)
    language sql
as $$
    update notes set is_deleted = true where id = note_id;
    analyze;
    $$;


