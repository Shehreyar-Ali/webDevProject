

select * from Major



insert into School
values(1)


insert into Major(majorID, majorName, School_schoolID)
values(1, 'CS', 1)


insert into Major(majorID, majorName, School_schoolID)
values(2, 'EE', 1)

insert into Admin
values(1, 'testAdmin@habib.com', '123456')


insert into Admin
values(2, 'secondAdmin@habib.com', 'abcdef')

insert into Student(stuID, loginStu, passwordStu, Major_majorID)
values(03576, 'sa03576', '112233445566', 1)

insert into Student(stuID, loginStu, passwordStu, Major_majorID)
values(111, 'rk111', '666', 1)

insert into Student(stuID, loginStu, passwordStu, Major_majorID)
values(001, 'rand001', '999', 2)

select * from Student