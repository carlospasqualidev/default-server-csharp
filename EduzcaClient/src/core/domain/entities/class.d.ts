interface IClass {
  name: string;
  courseId: string | number;
  thumbnailUrl: string;
  description: string;
  order: number;
  text: string;
  videoUrl: string;
}

export interface Class extends IClass {}
