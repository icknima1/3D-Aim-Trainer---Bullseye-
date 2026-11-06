export interface Vector3 {
    x: number;
    y: number;
    z: number;
}

export interface GameObject {
    position: Vector3;
    rotation: Vector3;
    scale: Vector3;
    update: () => void;
    render: () => void;
}