precision highp float;

varying vec3 v_position;

uniform vec2 mouse;
uniform float elapsed;

void main() {
    float change = 0.0008;

    float r = cos(elapsed * change);
    float g = sin(elapsed * change);
    float b = sin(elapsed * change);

    float signR = r / abs(r);
    float signG = g / abs(g);
    float signB = b / abs(b);

    float mouseX = abs(mouse.x);
    float mouseY = abs(mouse.y);

    r = (r / 2.0 + 0.5) * v_position.x * mouseX;
    g = (g / 2.0 + 0.5) * v_position.y * mouseY;
    b = (b / 2.0 + 0.5) * v_position.x * mouseX;

    r = pow(r, 1.2) * signR;
    g = pow(g, 1.2) * signG;
    b = pow(b, 1.2) * signB;

    r = max(0.05, min(0.85, r));
    g = max(0.1, min(0.9, g));
    b = max(0.15, min(0.95, b));

    gl_FragColor = vec4(r, g, b, 0.8);
}
