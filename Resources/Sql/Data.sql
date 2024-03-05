INSERT INTO dbo.Class (Id, name, totalStudent) VALUES
('C001', 'Class A', 30),
('C002', 'Class B', 25),
('C003', 'Class C', 28),
('C004', 'Class D', 32),
('C005', 'Class E', 27),
('C006', 'Class F', 29),
('C007', 'Class G', 31),
('C008', 'Class H', 26),
('C009', 'Class I', 30),
('C010', 'Class J', 28);
go

INSERT INTO dbo.Department (Id, Name) VALUES
('D001', 'Mathematics Department'),
('D002', 'English Department'),
('D003', 'Physics Department'),
('D004', 'Biology Department'),
('D005', 'Chemistry Department'),
('D006', 'History Department'),
('D007', 'Geography Department'),
('D008', 'Literature Department'),
('D009', 'Computer Science Department'),
('D010', 'Economics Department');
go

INSERT INTO Role  (Name, Description, DateUpdated) 
VALUES 
('Admin', 'Description for Role 1', GETDATE()),
('Teacher', 'Description for Role 2', GETDATE());
go

INSERT INTO dbo.[User] (Id, FullName, Email, DateOfBirth, PhoneNumber, Address, Gender, Avartar, Password, isLocked, RoleId, DepartmentId) VALUES
('6F9619FF-8B86-D011-B42D-00C04FC964AA', 'John Doe', 'john@example.com', '1990-05-15', '1234567890', '123 Main Street, City, Country', 1, 'avatar1.jpg', 'hashedpassword1', 0, 3, 'D001'),
('6F9619FF-8B86-D011-B42D-00C04FC964BB', 'Jane Smith', 'jane@example.com', '1995-08-25', '9876543210', '456 Elm Street, City, Country', 2, 'avatar2.jpg', 'hashedpassword2', 0, 4, 'D002'),
('6F9619FF-8B86-D011-B42D-00C04FC964CC', 'Michael Johnson', 'michael@example.com', '1988-03-10', '4561237890', '789 Oak Street, City, Country', 1, 'avatar3.jpg', 'hashedpassword3', 0, 4, 'D003'),
('6F9619FF-8B86-D011-B42D-00C04FC964DD', 'Emily Brown', 'emily@example.com', '1992-11-02', '7894561230', '101 Pine Street, City, Country', 2, 'avatar4.jpg', 'hashedpassword4', 0, 4, 'D004'),
('6F9619FF-8B86-D011-B42D-00C04FC964EE', 'William Taylor', 'william@example.com', '1985-07-20', '3692581470', '202 Cedar Street, City, Country', 1, 'avatar5.jpg', 'hashedpassword5', 0, 4, 'D005'),
('6F9619FF-8B86-D011-B42D-00C04FC964FF', 'Sophia Martinez', 'sophia@example.com', '1998-09-18', '8529637410', '303 Maple Street, City, Country', 2, 'avatar6.jpg', 'hashedpassword6', 0, 4, 'D006'),
('6F9619FF-8B86-D011-B42D-00C04FC96411', 'Matthew Anderson', 'matthew@example.com', '1993-12-05', '1472583690', '404 Walnut Street, City, Country', 1, 'avatar7.jpg', 'hashedpassword7', 0, 4, 'D007'),
('6F9619FF-8B86-D011-B42D-00C04FC96422', 'Olivia Wilson', 'olivia@example.com', '1987-04-30', '3691472580', '505 Hickory Street, City, Country', 2, 'avatar8.jpg', 'hashedpassword8', 0, 4, 'D008'),
('6F9619FF-8B86-D011-B42D-00C04FC96433', 'Daniel Garcia', 'daniel@example.com', '1991-10-12', '9638527410', '606 Pineapple Street, City, Country', 1, 'avatar9.jpg', 'hashedpassword9', 0, 4, 'D009'),
('6F9619FF-8B86-D011-B42D-00C04FC96444', 'Ava Rodriguez', 'ava@example.com', '1996-06-28', '2589631470', '707 Peach Street, City, Country', 2, 'avatar10.jpg', 'hashedpassword10', 0, 4, 'D010');
go

UPDATE dbo.Subject
SET TeacherId = '6F9619FF-8B86-D011-B42D-00C04FC964BB'
WHERE Id = 'Chemistry101';
go


INSERT INTO dbo.Subject (Id, Name, SubmissionDate, Description, DepartmentId, TeacherId) VALUES
('Math101', 'Mathematics', '2023-01-01 08:00:00', 'Introduction to Mathematics', 'D001', '6F9619FF-8B86-D011-B42D-00C04FC96422'),
('English101', 'English', '2023-01-01 09:00:00', 'Introduction to English Literature', 'D002', '6F9619FF-8B86-D011-B42D-00C04FC964CC'),
('Physics101', 'Physics', '2023-01-01 10:00:00', 'Introduction to Physics', 'D003', '6F9619FF-8B86-D011-B42D-00C04FC964DD'),
('Biology101', 'Biology', '2023-01-01 11:00:00', 'Introduction to Biology', 'D004', '6F9619FF-8B86-D011-B42D-00C04FC964EE'),
('Chemistry101', 'Chemistry', '2023-01-01 12:00:00', 'Introduction to Chemistry', 'D005', '6F9619FF-8B86-D011-B42D-00C04FC964BB11');
go


INSERT INTO dbo.ClassSubject (classId, subjectId) VALUES
('C001', 'Math101'),
('C001', 'English101'),
('C002', 'Math101'),
('C002', 'Physics101'),
('C003', 'Biology101'),
('C003', 'Chemistry101');
go

INSERT INTO dbo.Document (Name, Type, submissionDate, updatedDate, FilePath, status, note, lessonId, censorId, teacherCreatedId) VALUES
('Guide on Using Microsoft Excel Tool', 1, '2024-03-06 08:00:00', '2024-03-06 08:00:00', 'path/to/excel_guide.pdf', 1, 'Detailed guide on how to use Excel', 1, '6F9619FF-8B86-D011-B42D-00C04FC964AA', '6F9619FF-8B86-D011-B42D-00C04FC96422'),
('Lecture on Basic Grammar Rules', 0, '2024-03-06 09:00:00', '2024-03-06 09:00:00', 'path/to/grammar_rules.pptx', 1, 'Lecture presenting basic grammar rules in English', 2, '6F9619FF-8B86-D011-B42D-00C04FC964BB', '6F9619FF-8B86-D011-B42D-00C04FC964CC'),
('Physics Experiment on Conservation of Momentum', 1, '2024-03-06 10:00:00', '2024-03-06 10:00:00', 'path/to/momentum_experiment.docx', 1, 'Report on an experiment on conservation of momentum in physics', 3, '6F9619FF-8B86-D011-B42D-00C04FC964CC', '6F9619FF-8B86-D011-B42D-00C04FC964DD'),
('Guide on Molecular Biology', 0, '2024-03-06 11:00:00', '2024-03-06 11:00:00', 'path/to/molecular_biology_guide.pdf', 1, 'Detailed guide on molecular biology', 4, '6F9619FF-8B86-D011-B42D-00C04FC964DD', '6F9619FF-8B86-D011-B42D-00C04FC964EE'),
('Lecture on Atomic Structure and Chemical Bonding', 1, '2024-03-06 12:00:00', '2024-03-06 12:00:00', 'path/to/atomic_structure_chemistry_lecture.pdf', 1, 'Lecture presenting atomic structure and chemical bonding', 5, '6F9619FF-8B86-D011-B42D-00C04FC964EE', '6F9619FF-8B86-D011-B42D-00C04FC964BB'),
('Lecture on Medieval History', 0, '2024-03-06 13:00:00', '2024-03-06 13:00:00', 'path/to/medieval_history_lecture.pptx', 1, 'Lecture presenting medieval history', 6, '6F9619FF-8B86-D011-B42D-00C04FC964BB', '6F9619FF-8B86-D011-B42D-00C04FC964CC'),
('Lecture on Geography of Africa', 1, '2024-03-06 14:00:00', '2024-03-06 14:00:00', 'path/to/africa_geography_lecture.pptx', 1, 'Lecture presenting geography of the Africa region', 7, '6F9619FF-8B86-D011-B42D-00C04FC964CC', '6F9619FF-8B86-D011-B42D-00C04FC964DD'),
('Literature Work "Freedom"', 0, '2024-03-06 15:00:00', '2024-03-06 15:00:00', 'path/to/literature_work_freedom.pdf', 1, 'Famous literature work "Freedom" by author XYZ', 8, '6F9619FF-8B86-D011-B42D-00C04FC964DD', '6F9619FF-8B86-D011-B42D-00C04FC964EE'),
('Guide on Basic Python Programming', 1, '2024-03-06 16:00:00', '2024-03-06 16:00:00', 'path/to/basic_python_guide.pdf', 1, 'Basic guide on Python programming', 9, '6F9619FF-8B86-D011-B42D-00C04FC964EE', '6F9619FF-8B86-D011-B42D-00C04FC964BB'),
('Lecture on Basic Principles of Economics', 0, '2024-03-06 17:00:00', '2024-03-06 17:00:00', 'path/to/basic_economics_lecture.pptx', 1, 'Lecture presenting basic principles of economics', 10, '6F9619FF-8B86-D011-B42D-00C04FC964BB', '6F9619FF-8B86-D011-B42D-00C04FC964CC');
go

// Cột lesson 