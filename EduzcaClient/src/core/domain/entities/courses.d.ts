interface ICourse {
  id: number;
  name: string;
  thumbnailUrl: string;
  description: string;
  ownerId: number;
}

export interface Course extends ICourse {}
