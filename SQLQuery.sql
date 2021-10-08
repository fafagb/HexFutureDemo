

select c.ClassID ,c.Name as "班级名称" ,s.StudentID,s.Name as "学生姓名" from  GB_Class c  
left join   GB_ClassStudentRelationship  r  on   c.ClassID=r.ClassID
left join   GB_Student   s  on  r.StudentID =  s.StudentID


delete from  GB_Grade;
delete from  GB_Student;
delete from  GB_Class;
delete from  GB_ClassStudentRelationship;

select *  from  GB_Grade;
select *  from   GB_Student;
select *  from  GB_Class;
select  *   from   GB_ClassStudentRelationship;

delete  from    GB_ClassStudentRelationship   where  StudentID='21612276041373'






SELECT GB_ClassStudentRelationship_0.ClassStudentRelationshipID as __0__ClassStudentRelationship_Key, GB_ClassStudentRelationship_0.ClassID as __1__ClassStudentRelationship_GClass_Key, GB_ClassStudentRelationship_0.ClassID as __1__GClass_Key, GB_Class_GClass_1.ClassID as __1__GClass_Key1, GB_Class_GClass_1.Name as __1__GClass_Name, GB_Class_GClass_1.GradeID as __2__GClass_Grade_Key, GB_Class_GClass_1.CreateTime as __1__GClass_CreateTime, GB_Class_GClass_1.LastUpdateTime as __1__GClass_LastUpdateTime, GB_ClassStudentRelationship_0.StudentID as __1__ClassStudentRelationship_Student_Key, GB_ClassStudentRelationship_0.StudentID as __1__Student_Key, GB_Student_Student_1.StudentID as __1__Student_Key1, GB_Student_Student_1.Name as __1__Student_Name, GB_Student_Student_1.Sex as __1__Student_Sex, GB_Student_Student_1.StudentCode as __1__Student_StudentCode, GB_Student_Student_1.CreateTime as __1__Student_CreateTime, GB_Student_Student_1.LastUpdateTime as __1__Student_LastUpdateTime, GB_ClassStudentRelationship_0.CreateTime as __0__ClassStudentRelationship_CreateTime, GB_ClassStudentRelationship_0.LastUpdateTime as __0__ClassStudentRelationship_LastUpdateTime from GB_ClassStudentRelationship as GB_ClassStudentRelationship_0 left join GB_Class as GB_Class_GClass_1 on GB_ClassStudentRelationship_0.ClassID = GB_Class_GClass_1.ClassID left join GB_Student as GB_Student_Student_1 on GB_ClassStudentRelationship_0.StudentID = GB_Student_Student_1.StudentID






SELECT GB_Class_0.ClassID as __0__GClass_Key, GB_Class_0.Name as __0__GClass_Name, GB_Class_0.GradeID as __1__GClass_Grade_Key, GB_Class_0.GradeID as __1__Grade_Key, GB_Grade_Grade_1.GradeID as __1__Grade_Key1, GB_Grade_Grade_1.Name as __1__Grade_Name, GB_Grade_Grade_1.CreateTime as __1__Grade_CreateTime, GB_Grade_Grade_1.LastUpdateTime as __1__Grade_LastUpdateTime, GB_Class_0.CreateTime as __0__GClass_CreateTime, GB_Class_0.LastUpdateTime as __0__GClass_LastUpdateTime from GB_Class as GB_Class_0 left join GB_Grade as GB_Grade_Grade_1 on GB_Class_0.GradeID = GB_Grade_Grade_1.GradeID








