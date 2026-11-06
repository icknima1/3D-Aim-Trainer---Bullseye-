class Target {
    position: { x: number; y: number; z: number };
    size: number;

    constructor(x: number, y: number, z: number, size: number) {
        this.position = { x, y, z };
        this.size = size;
    }

    render(context: WebGLRenderingContext) {
        // Implement rendering logic for the target
    }

    update(deltaTime: number) {
        // Implement update logic for the target
    }
}

export default Target;