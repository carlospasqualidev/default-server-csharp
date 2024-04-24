"use client";

import { useEffect, useState } from "react";

import { Input } from "@/components/ui/input";
import { Button } from "@/components/ui/button";

import { Course } from "@/core/domain/entities/courses";

interface CourseProps {
  params: { id: number | string };
}

export default function Course({ params }: CourseProps) {
  const [course, setCourse] = useState<Course | null>(null);

  const courseId = params.id;

  useEffect(() => {});

  return (
    <section className="m-auto h-full w-1/2 px-10 gap-6 flex flex-col justify-center items-center pb-10">
      <img
        src="https://assets-global.website-files.com/6092ed75cac3156e208ac5e9/64a76ee038423d0aebf23ad3_nest-thumb.webp"
        className="w-full rounded-md"
      />

      <span className="text-2xl font-semibold">Nest.js</span>

      <Input type="text" placeholder="Nome" />
      <Input type="text" placeholder="Descrição" />
      <Input type="text" placeholder="Thumbnail" />

      <Button className="w-1/2">Salvar alterações</Button>
    </section>
  );
}
