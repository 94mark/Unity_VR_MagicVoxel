# VR Magic Voxel 제작
![imge3](https://user-images.githubusercontent.com/90877724/156960386-cc64d333-1fe2-4754-be8f-e3b569f06709.png)

## 1. 프로젝트 개요
### 1.1 개발 인원/기간 및 포지션
- 1인, 총 3일 소요
- 프로그래밍 (VR환경 구축 및 개발)
### 1.2 개발 환경
- Unity 2020.3.13f
- VR HMD : Oculus Quest 2
- 언어 : C#
- OS : Window 10			
## 2. 개발 단계
### 2.1 벤치마킹
- 복셀 아트 (Voxel Art) 참고
- VR 프로젝트에 맞는 디자인/ 성능 최적화 목표 
### 2.2 기획 및 프로토타입
- PC 기준 3D 콘텐츠 제작 후 VR 컨트롤러 대응으로 변환
- 프로토타입 : PC 버전
- 알파 : VR 전환
## 3. 핵심 구현 내용 
### 3.1 카메라 회전
- 마우스 입력을 이용해 구한 회전 값을 transform의 eulerAnagles에 적용
### 3.2 복셀 생성 
- 복셀 생성 시 랜덤한 방향으로 날아가도록 Random.insideUnitSphere 사용
- Camera.main.ScreenPointToRayRaycast를 통해 마우스 위치가 바닥 위에 있는 것을 판
- Ray와 부딪힌 정보를 저장할 RaycastHit을 넘겨 충돌 체크
### 3.3 오브젝트 풀링
- Voxel Factory/Voxel Pool을 만들어 복셀 Instatiate 과정에서 메모리 파편화 및 로딩 시간 관리
### 3.4 VR 입력 대응
- Oculus Integration / OVRCameraRig 배치 및 ARAVRInput 클래스의 #OCULUS 매크로 활성화를 통해 Oculus Quest2 VR 환경 세팅
- Crosshair(조준점 이미지)를 RTOUCH(오른쪽 컨트롤러)와 연결한 DrawCrosshair 함수 호출 
## 4. 문제 해결 내용
### 4.1 오브젝트 풀링 
- VR 환경에 적합한 FPS(Frame Per Second, 초당 프레임률)를 향상시켜 인지 부조화 방지를 목표
- voxelPoolSize가 20인 voxelPool 리스트를 추가해 비활성화돼 있는 복셀을 담아 관리(for문을 돌려 voxelFactory에서 voxelPoolSize만큼의 voxel을 생성 후 비활성화하여 voxelPool에 Add)
- voxelPool.Count를 통해 오브젝트 풀에 복셀이 있다면 voxelPool[0]을 가져와 활성화하고, voxel.transfrom.position을 hitInfo.point에 입력 후 오브젝트 풀에서 RemoveAt(0) 함.
- 생성된 복셀이 일정 시간을 초과하면 다시 비활성화시킨 후 voxelPool에 반환
- voxel의 Rigidbody와 관련하여 랜덤한 속도 지정에 대한처리를 위해 Start()를 OnEnable()로 변경
### 4.2 Crosshair shader 속성 변경
- Crosshair 이미지 생성 시 Floor 객체에 가려 절반만 보이는 문제 발생
- UI가 월드 공간에 배치되기 때문에 Depth Testing 과정에서 일종의 Z-Fighting 현상이 발생하는 것(카메라 시점을 기준으로 오브젝트와의 간격이 더 짧은 객체를 먼저 보여주기 때문)
- Crosshair 이미지가 어떤 다른 객체들과 겹치더라도 가장 우선순위로 위에 나타나야 함(목표 설정)
- 유니티 Built-in Shader/UI-Defualt.shader 파일을 Crosshair Shader로 연결, SubShader 하위의 ZTest 속성을 Always로 변경, Crosshair Material에 매핑하여 문제 해결
- ZTest는 오브젝트가 그려질 때 ZBuffer의 해당 픽셀에 이미 기록된 깊이 값과 자신의 깊이 값을 비교하여, 자신의 픽셀을 렌더링할지 여부를 결정하는 연산
- Always 속성은 오브젝트 간 깊이값을 판단하지 않고 무조건 맨 앞에 렌더링하는 특징이 있음.
