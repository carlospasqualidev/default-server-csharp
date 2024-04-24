"use client";

import { useEffect, useState } from "react";
import Courses from "@/components/dashboard/courses";

import type { Course } from "@/core/domain/entities/courses";

import { Button } from "@/components/ui/button";

import * as CourseService from "@/services/courses";
import { useRouter } from "next/navigation";

const courses: Course[] = [
  {
    id: 1,
    name: "Curso de Next.js",
    description: "Curso focado em frontend",
    ownerId: 1,
    thumbnailUrl:
      "https://cdn.openwebinars.net/media/fbads-react-principiantes2.png",
  },
  {
    id: 2,
    name: "Nest.js",
    description: "Curso focado em backend",
    ownerId: 1,
    thumbnailUrl:
      "https://assets-global.website-files.com/6092ed75cac3156e208ac5e9/64a76ee038423d0aebf23ad3_nest-thumb.webp",
  },
];

export default function Dashboard() {
  const [courses, setCourses] = useState<Course[]>([]);
  const router = useRouter();

  const loadCourses = async () => {
    try {
      const response = await CourseService.getCourses();
      setCourses(response.data);
    } catch (error) {
      console.error(error);
    }
  };

  useEffect(() => {
    loadCourses();
  }, []);

  const onClickCreateCourse = () => {
    router.push("/dashboard/course/create");
  };

  return (
    <section className="h-full px-10 flex flex-col gap-6">
      <span className="text-2xl font-semibold w-full flex justify-between">
        Meus Cursos <Button onClick={onClickCreateCourse}>Criar curso</Button>
      </span>

      <div className="grid grid-cols-4 gap-4">
        {courses.map((course) => (
          <Courses key={course.id} course={course} />
        ))}
      </div>
    </section>
  );
}
