import socket
import json

HOST = 'localhost'                 # Symbolic name meaning all available interfaces
PORT = 8888                        # Arbitrary non-privileged port
with socket.socket(socket.AF_INET, socket.SOCK_STREAM) as s:
    s.bind((HOST, PORT))
    s.listen(1)
    conn, addr = s.accept()
    with conn:
        print('Connected by', addr)
        while True:
            data = conn.recv(1024)
            if not data:
                break
            data = json.loads(data.decode('utf-8'))
            ans = list(data.values())[0]*2

            ans_d = json.dumps(ans).encode('utf-8')

            conn.sendall(ans_d)