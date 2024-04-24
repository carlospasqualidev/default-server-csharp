import { api } from "./api";

import { Course } from "@/core/domain/entities/courses";

export const getCourseById = async (id: number) => {
  return api.get(`/Courses/${id}`);
};

export const getCourses = async () => {
  return api.get(`/Courses`);
};

export const createCourse = async (data: Course) => {
  return api.post("/Courses", data);
};
