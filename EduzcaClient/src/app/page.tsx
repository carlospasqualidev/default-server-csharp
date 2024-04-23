import Image from "next/image";

import SignIn from "@/components/home/signin";
import SignUp from "@/components/home/signup";
import { Tabs, TabsContent, TabsList, TabsTrigger } from "@/components/ui/tabs";

export default function Home() {
  return (
    <main className="flex flex-col justify-center items-center h-full gap-10">
      <Image
        src="/logo.png"
        width={200}
        height={200}
        loading="lazy"
        alt="Logo"
      />

      <Tabs defaultValue="account" className="w-[400px]">
        <TabsList>
          <TabsTrigger value="account">Login</TabsTrigger>
          <TabsTrigger value="password">Cadastro</TabsTrigger>
        </TabsList>
        <TabsContent value="account">
          <SignIn />
        </TabsContent>
        <TabsContent value="password">
          <SignUp />
        </TabsContent>
      </Tabs>
    </main>
  );
}
