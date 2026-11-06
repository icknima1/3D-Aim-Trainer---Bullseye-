export class HUD {
    private score: number;
    private timer: number;

    constructor() {
        this.score = 0;
        this.timer = 0;
    }

    public updateScore(points: number): void {
        this.score += points;
    }

    public updateTimer(deltaTime: number): void {
        this.timer += deltaTime;
    }

    public render(ctx: CanvasRenderingContext2D): void {
        ctx.fillStyle = 'white';
        ctx.font = '20px Arial';
        ctx.fillText(`Score: ${this.score}`, 10, 30);
        ctx.fillText(`Time: ${Math.floor(this.timer)}`, 10, 60);
    }

    public reset(): void {
        this.score = 0;
        this.timer = 0;
    }
}