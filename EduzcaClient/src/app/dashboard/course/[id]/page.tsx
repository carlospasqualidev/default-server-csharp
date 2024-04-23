import { Input } from "@/components/ui/input";
import { Button } from "@/components/ui/button";

interface CourseProps {
  params: { id: number | string };
}

export default function Course({ params }: CourseProps) {
  const courseId = params.id;

  return (
    <section className="m-auto h-full w-1/2 px-10 gap-6 flex flex-col justify-center items-center">
      <Input type="text" placeholder="Nome" />
      <Input type="text" placeholder="Descrição" />

      <Button className="w-1/2">Salvar</Button>
    </section>
  );
}
