import Courses from "@/components/dashboard/courses";
import Navbar from "@/components/dashboard/navbar";

export default function Dashboard() {
  return (
    <main className="h-full px-10">
      <Navbar />

      <Courses />
    </main>
  );
}
