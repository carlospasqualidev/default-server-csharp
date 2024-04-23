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
import Image from "next/image";
import CoursesDropdown from "../courses-dropdown";

import { Course } from "@/core/domain/entities/courses";

interface CoursesProps {
  course: Course;
}

const Courses: React.FC<CoursesProps> = ({ course }) => {
  return (
    <Card>
      <CardHeader>
        <Image
          src="/logo.png"
          width={80}
          height={80}
          loading="lazy"
          alt="Logo"
        />
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
