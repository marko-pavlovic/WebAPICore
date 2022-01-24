﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebAPICore.Models;

namespace WebAPICore.IServices
{
    public interface IAdminService
    {
        IEnumerable<Course> GetCourse();
        Course AddCourse(Course course);
        IEnumerable<Student> GetStudent();
        Student AddStudent(Student student);
    }
}
