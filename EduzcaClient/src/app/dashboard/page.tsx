import Courses from "@/components/dashboard/courses";

import type { Course } from "@/core/domain/entities/courses";

const courses: Course[] = [
  {
    id: 1,
    name: "Curso de Next.js",
    description: "Curso focado em frontend",
    thumbnailUrl: "",
  },
  {
    id: 2,
    name: "Nest.js",
    description: "Curso focado em backend",
    thumbnailUrl: "",
  },
];

export default function Dashboard() {
  return (
    <section className="h-full px-10 flex flex-col gap-6">
      <span className="text-2xl font-semibold">Meus Cursos</span>

      <div className="grid grid-cols-4 gap-4">
        {courses.map((course) => (
          <Courses key={course.id} course={course} />
        ))}
      </div>
    </section>
  );
}
