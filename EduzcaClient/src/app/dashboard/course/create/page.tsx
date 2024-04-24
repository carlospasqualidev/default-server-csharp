"use client";

import { useState } from "react";

import { Input } from "@/components/ui/input";
import { Button } from "@/components/ui/button";

import { Course } from "@/core/domain/entities/courses";

import * as CourseService from "@/services/courses";

export default function Course() {
  const [form, setForm] = useState<Course>({
    name: "",
    thumbnailUrl: "",
    description: "",
  });
  const [loading, setLoading] = useState(false);

  const onCreateCourse = async () => {
    try {
      setLoading(true);
      await CourseService.createCourse(form);
    } catch (error) {
      console.error(error);
    } finally {
      setLoading(false);
    }
  };

  return (
    <section className="m-auto h-full w-1/2 px-10 gap-6 flex flex-col justify-center items-center pb-10">
      <span className="text-2xl font-semibold">Criar curso</span>

      <Input type="text" placeholder="Nome do curso" />
      <Input type="text" placeholder="Thumbnail" />
      <Input type="text" placeholder="Descrição" />

      <Button className="w-1/2" onClick={onCreateCourse} disabled={loading}>
        Criar curso
      </Button>
    </section>
  );
}
