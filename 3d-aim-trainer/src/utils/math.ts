export function addVectors(a: { x: number; y: number; z: number }, b: { x: number; y: number; z: number }): { x: number; y: number; z: number } {
    return { x: a.x + b.x, y: a.y + b.y, z: a.z + b.z };
}

export function subtractVectors(a: { x: number; y: number; z: number }, b: { x: number; y: number; z: number }): { x: number; y: number; z: number } {
    return { x: a.x - b.x, y: a.y - b.y, z: a.z - b.z };
}

export function dotProduct(a: { x: number; y: number; z: number }, b: { x: number; y: number; z: number }): number {
    return a.x * b.x + a.y * b.y + a.z * b.z;
}

export function crossProduct(a: { x: number; y: number; z: number }, b: { x: number; y: number; z: number }): { x: number; y: number; z: number } {
    return {
        x: a.y * b.z - a.z * b.y,
        y: a.z * b.x - a.x * b.z,
        z: a.x * b.y - a.y * b.x,
    };
}

export function length(vector: { x: number; y: number; z: number }): number {
    return Math.sqrt(vector.x * vector.x + vector.y * vector.y + vector.z * vector.z);
}

export function normalize(vector: { x: number; y: number; z: number }): { x: number; y: number; z: number } {
    const len = length(vector);
    return len > 0 ? { x: vector.x / len, y: vector.y / len, z: vector.z / len } : { x: 0, y: 0, z: 0 };
}