﻿namespace CourseApp.Models.Course
{
    public class UpdateCourseDto
    {
        
        public int Id { get; set; }
        public string Name { get; set; }
        public double Price { get; set; }

        public string Description { get; set; }
    }
}