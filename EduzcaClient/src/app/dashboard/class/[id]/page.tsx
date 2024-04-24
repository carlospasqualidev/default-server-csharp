"use client";

import { useState } from "react";

import { Class } from "@/core/domain/entities/class";

import { Button } from "@/components/ui/button";
import { Input } from "@/components/ui/input";

import * as ClassService from "@/services/class";

interface ClassProps {
  params: { id: number | string };
}

export default function Class({ params }: ClassProps) {
  const [form, setForm] = useState<Class>({
    name: "",
    courseId: 1,
    thumbnailUrl: "",
    description: "",
    order: 1,
    text: "",
    videoUrl: "",
  });
  const [isLoading, setIsLoading] = useState(false);

  const courseId = params.id;

  const createClass = async () => {
    try {
      setIsLoading(true);
      const data = { ...form, courseId };
      await ClassService.createClass(data);
    } catch (error) {
      console.error(error);
    } finally {
      setIsLoading(false);
    }
  };

  const onChange = (
    key: keyof Class,
    e: React.ChangeEvent<HTMLInputElement>
  ) => {
    setForm({ ...form, [key]: e.target.value });
  };

  return (
    <section className="m-auto h-full w-1/2 px-10 gap-6 flex flex-col justify-center items-center pb-10">
      <span className="text-2xl font-semibold">Cadastrar aula</span>

      <Input
        type="text"
        placeholder="Nome da aula"
        onChange={(event) => onChange("name", event)}
      />
      <Input
        type="text"
        placeholder="Descrição"
        onChange={(event) => onChange("description", event)}
      />
      <Input
        type="text"
        placeholder="Thumbnail"
        onChange={(event) => onChange("thumbnailUrl", event)}
      />
      <Input
        type="text"
        placeholder="Texto"
        onChange={(event) => onChange("text", event)}
      />
      <Input
        type="text"
        placeholder="URL do video"
        onChange={(event) => onChange("videoUrl", event)}
      />

      <Button className="w-1/2" onClick={createClass} disabled={isLoading}>
        Criar aula
      </Button>
    </section>
  );
}
