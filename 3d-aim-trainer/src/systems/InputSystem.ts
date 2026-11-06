export class InputSystem {
    private keys: Set<string>;
    private mousePosition: { x: number; y: number };

    constructor() {
        this.keys = new Set();
        this.mousePosition = { x: 0, y: 0 };

        this.initializeInput();
    }

    private initializeInput() {
        window.addEventListener('keydown', (event) => this.keys.add(event.key));
        window.addEventListener('keyup', (event) => this.keys.delete(event.key));
        window.addEventListener('mousemove', (event) => {
            this.mousePosition.x = event.clientX;
            this.mousePosition.y = event.clientY;
        });
    }

    public isKeyPressed(key: string): boolean {
        return this.keys.has(key);
    }

    public getMousePosition(): { x: number; y: number } {
        return this.mousePosition;
    }
}