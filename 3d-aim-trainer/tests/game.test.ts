import { GameScene } from '../src/scenes/GameScene';
import { Target } from '../src/components/Target';
import { HUD } from '../src/components/HUD';

describe('GameScene', () => {
    let gameScene: GameScene;

    beforeEach(() => {
        gameScene = new GameScene();
    });

    test('should initialize with default values', () => {
        expect(gameScene).toBeDefined();
        expect(gameScene.targets).toHaveLength(0);
        expect(gameScene.score).toBe(0);
    });

    test('should spawn targets', () => {
        gameScene.spawnTargets(5);
        expect(gameScene.targets).toHaveLength(5);
    });

    test('should update score when target is hit', () => {
        const target = new Target();
        gameScene.targets.push(target);
        gameScene.hitTarget(target);
        expect(gameScene.score).toBe(1);
    });
});

describe('Target', () => {
    let target: Target;

    beforeEach(() => {
        target = new Target();
    });

    test('should have a position', () => {
        expect(target.position).toBeDefined();
    });

    test('should be renderable', () => {
        const renderResult = target.render();
        expect(renderResult).toBeTruthy();
    });
});

describe('HUD', () => {
    let hud: HUD;

    beforeEach(() => {
        hud = new HUD();
    });

    test('should display score', () => {
        hud.updateScore(10);
        expect(hud.scoreDisplay).toContain('Score: 10');
    });

    test('should display timer', () => {
        hud.updateTimer(30);
        expect(hud.timerDisplay).toContain('Time: 30');
    });
});