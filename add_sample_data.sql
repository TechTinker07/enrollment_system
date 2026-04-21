-- 1. I-RUN ITO PARA MADAGDAG ANG MGA SUBJECTS MULA SA COR
INSERT IGNORE INTO `subjects` (`subject_code`, `subject_title`, `subject_type`, `department`, `units`) VALUES
('106-GAD213', '2D and 3D Digital Animation', 'Lecture/Lab', 'Information Technology', 3),
('106-SAD313', 'System Analysis, Design and Development', 'Lecture', 'Information Technology', 3),
('106-ELEC313', 'IT Elective 2', 'Lecture/Lab', 'Information Technology', 3),
('106-CC313', 'Application Devt and Emerging Technologies', 'Lecture/Lab', 'Information Technology', 3),
('106-IPT313', 'Integrative Prog''g & Technologies 1', 'Lecture/Lab', 'Information Technology', 3);

-- 2. I-RUN ITO PARA MAGKAROON SILA NG SCHEDULE SA SECTION BSIT-31E2
INSERT INTO `schedules` (`subject_id`, `faculty_user_id`, `section`, `days`, `time_start`, `time_end`, `room`) VALUES
((SELECT subject_id FROM subjects WHERE subject_code = '106-GAD213'), NULL, 'BSIT-31E2', 'M, W', '13:00:00', '14:30:00', 'LAB 3'),
((SELECT subject_id FROM subjects WHERE subject_code = '106-SAD313'), NULL, 'BSIT-31E2', 'T, TH', '09:00:00', '10:30:00', 'ROOM 305'),
((SELECT subject_id FROM subjects WHERE subject_code = '106-ELEC313'), NULL, 'BSIT-31E2', 'M, W', '15:00:00', '16:30:00', 'LAB 2'),
((SELECT subject_id FROM subjects WHERE subject_code = '106-CC313'), NULL, 'BSIT-31E2', 'T, TH', '13:00:00', '14:30:00', 'LAB 1'),
((SELECT subject_id FROM subjects WHERE subject_code = '106-IPT313'), NULL, 'BSIT-31E2', 'F', '08:00:00', '11:00:00', 'LAB 4');
