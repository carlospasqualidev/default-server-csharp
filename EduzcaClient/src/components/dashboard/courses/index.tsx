"use client";

import React from "react";

import {
  Card,
  CardContent,
  CardDescription,
  CardHeader,
  CardTitle,
} from "@/components/ui/card";
import { Button } from "@/components/ui/button";

import CoursesDropdown from "../courses-dropdown";

import { Course } from "@/core/domain/entities/courses";

interface CoursesProps {
  course: Course;
}

const Courses: React.FC<CoursesProps> = ({ course }) => {
  return (
    <Card>
      <CardHeader>
        <img src={course.thumbnailUrl} className="w-full rounded-md mb-4" />

        <CardTitle className="flex justify-between">
          {course.name} <CoursesDropdown courseId={course.id} />
        </CardTitle>
        <CardDescription>{course.description}</CardDescription>
      </CardHeader>
      <CardContent>
        <Button className="w-full">Ver curso</Button>
      </CardContent>
    </Card>
  );
};

export default Courses;
