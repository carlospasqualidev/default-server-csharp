interface ICourse {
  id: number;
  name: string;
  thumbnailUrl: string;
  description: string;
}

export interface Course extends ICourse {}
