"use client";

import Link from "next/link";
import Image from "next/image";

import {
  NavigationMenu,
  NavigationMenuItem,
  NavigationMenuLink,
  NavigationMenuList,
} from "@/components/ui/navigation-menu";
import { navigationMenuTriggerStyle } from "@/components/ui/navigation-menu";

const Navbar: React.FC = () => {
  return (
    <NavigationMenu className="mb-8 px-10">
      <NavigationMenuList>
        <NavigationMenuItem className="cursor-pointer">
          <Link href="/dashboard" legacyBehavior passHref>
            <Image
              src="/logo.png"
              width={80}
              height={80}
              loading="lazy"
              alt="Logo"
            />
          </Link>
        </NavigationMenuItem>

        <NavigationMenuItem>
          <Link href="/courses" legacyBehavior passHref>
            <NavigationMenuLink className={navigationMenuTriggerStyle()}>
              Gerenciar cursos
            </NavigationMenuLink>
          </Link>
          <Link href="/" legacyBehavior passHref>
            <NavigationMenuLink className={navigationMenuTriggerStyle()}>
              Sair
            </NavigationMenuLink>
          </Link>
        </NavigationMenuItem>
      </NavigationMenuList>
    </NavigationMenu>
  );
};

export default Navbar;
