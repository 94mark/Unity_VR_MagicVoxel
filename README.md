VR Magic Voxel 제작
----
	1. 프로젝트 개요
		1) 개발 인원/기간 및 포지션
			- 1인, 총 3일 소요
			- 프로그래밍 (VR환경 구축 및 개발)
		2) 개발 환경
			- Unity 2021.3.16f
			- VR HMD : Oculus Quest 2
			- 언어 : C#
			- OS : Window 10
			
	2. 개발 단계
		1) 벤치마킹
			- 복셀 아트 (Voxel Art) 참고
			- VR 프로젝트에 맞는 디자인/ 성능 최적화 목표 
		2) 기획 및 프로토타입
			- PC 기준 3D 콘텐츠 제작 후 VR 컨트롤러 대응으로 변환
			- 프로토타입 : PC 버전
			- 알파 : VR 전환

	3. 개발 내용 설명 
		1) 카메라 회전
			- 마우스 입력을 이용해 구한 회전 값을 transform의 eulerAnagles에 적용
		2) 복셀 생성 
			- 복셀 생성 시 랜덤한 방향으로 날아가도록 Random.insideUnitSphere 사용
			- Camera.main.ScreenPointToRayRaycast를 통해 마우스 위치가 바닥 위에 있는 것을 판단,
		3) 오브젝트 풀 사용 : 메모리 파편화 및 로딩 시간 관리
	4. 핵심 구현 내용
