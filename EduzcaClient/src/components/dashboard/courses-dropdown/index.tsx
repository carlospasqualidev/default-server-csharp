import React from "react";

import { useRouter } from "next/navigation";

import {
  DropdownMenu,
  DropdownMenuContent,
  DropdownMenuLabel,
  DropdownMenuTrigger,
} from "@/components/ui/dropdown-menu";

interface CoursesDropdownProps {
  courseId: number | string;
}

const CoursesDropdown: React.FC<CoursesDropdownProps> = ({ courseId }) => {
  const router = useRouter();
  const courseURL = `/dashboard/course/${courseId}`;
  const classURL = `/dashboard/class/${courseId}`;

  return (
    <DropdownMenu>
      <DropdownMenuTrigger>:</DropdownMenuTrigger>
      <DropdownMenuContent>
        <DropdownMenuLabel
          className="cursor-pointer outline-none"
          onClick={() => router.push(courseURL)}
        >
          Editar
        </DropdownMenuLabel>
        <DropdownMenuLabel
          className="cursor-pointer outline-none"
          onClick={() => router.push(classURL)}
        >
          Criar aula
        </DropdownMenuLabel>
      </DropdownMenuContent>
    </DropdownMenu>
  );
};

export default CoursesDropdown;
