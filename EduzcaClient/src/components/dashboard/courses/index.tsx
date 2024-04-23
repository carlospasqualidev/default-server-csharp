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

const Courses: React.FC = () => {
  return (
    <section className="flex flex-col gap-6">
      <span className="text-2xl font-semibold">Meus Cursos</span>

      <div className="grid grid-cols-4 gap-4">
        <Card>
          <CardHeader>
            <Image
              src="/logo.png"
              width={80}
              height={80}
              loading="lazy"
              alt="Logo"
            />
            <CardTitle>Nome do curso</CardTitle>
            <CardDescription>Card Description</CardDescription>
          </CardHeader>
          <CardContent>
            <Button className="w-full">Ver curso</Button>
          </CardContent>
        </Card>
      </div>
    </section>
  );
};

export default Courses;
