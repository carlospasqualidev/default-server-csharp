import { api } from "./api";

import { Course } from "@/core/domain/entities/courses";

export const getCourseById = async (id: number) => {
  return api.get(`/Course/${id}`);
};

export const getCourses = async () => {
  return api.get(`/Course`);
};

export const createCourse = async (data: Course) => {
  return api.post("/Course", data);
};
