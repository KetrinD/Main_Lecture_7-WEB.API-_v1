﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Models.Models;

namespace Web.Api.Demo.Controllers
{
    public class CoursesController : ControllerBase
    {
        private readonly Repository _repository;
        private readonly IConfiguration _configuration;

        public CoursesController(Repository repository, IConfiguration configuration)
        {
            _repository = repository;
            _configuration = configuration;
        }

        //CreateCourse
        [HttpPost]
        public ActionResult<Course> CreateCourse([FromBody] Course course)
        {
            var newCourse = _repository.CreateCourse(course);
            return newCourse;
        }

        //GetCourseById
        [HttpGet]
        public ActionResult<Course> GetCourseById ([FromRoute] int id)
        {
            var course = _repository.GetCourse(id);

            if (course == null)
            {
                return NotFound();
            }

            return course;
        }

        //GetAllCourses
        [HttpGet]
        public ActionResult<List<Course>> GetAllCourses()
        {
            var courses = _repository.GetAllCourses();
            return courses;
        }

        //UpdateCourseById
        [HttpPut]
        public ActionResult<Course> UpdateCourseById([FromBody]Course course)
        {
            _repository.UpdateCourse(course);
            return course;
        }

        //DeleteCourseById
        [HttpDelete]
        public string DeleteCourseById([FromRoute] int id)
        {
            _repository.DeleteCourse(id);
            return "ok";
        }


        //SetStudentsToCourse
        [HttpPost]
        public Course SetStudentsToCourse([FromRoute] int courseId, IEnumerable<int> studentsId)
        {
            _repository.SetStudentsToCourse(courseId, studentsId);
            var course = _repository.GetCourse(courseId);
            return course;
        }

        //GetStudentsByCourseId
        [HttpGet]
        public ActionResult<List<Student>> GetStudentsByCourseId([FromRoute] int courseId)
        {
            var students = _repository.GetStudentsByCourseId(courseId);
            return students;
        }

    }
}



////UpdateStudentsInCourse
//[HttpPut]
//public Course UpdateStudentsInCourse(int courseId, IEnumerable<int> studentsId)
//{
//    var student = _repository.GetStudentById(studentsId);
//}


////DeleteStudentsFromCourse
//[HttpPost]
//public Course DeleteStudentsFromCourse([FromRoute] int courseId, IEnumerable<int> studentsId)
//{
//    _repository.remo
//    var course = _repository.GetCourse(courseId);
//    return course;
//}