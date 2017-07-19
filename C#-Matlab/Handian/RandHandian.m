
function [mPLB,PLB,mPRB,PRB,mPLU,PLU,mPRU,PRU] = RandHandian(length,width,yover,minidistP2P,NumofP)

%width  = 1500;
%length = 1500;
%minidistP2P = 50;
% 
% NumofP =40;
% P=[553,	 49,1,0;   %x,y,形状材料(1:8ABS; 2:8PP; 3:7ABS; 4:7PP; 5:方1PP;% 6:方2ABS; 7：方3PP; 8: 方4PP)   指定工位 1-3
% 570,	100,1,0;
% 571,	163,1,0;
% 576,	233,1,0;
% 581,	308,1,0;
% 587,	383,1,0;
% 593,	458,1,0;
% 600,	538,1,0;
% 606,	613,1,0;
% 621,	634,1,0;
% 629,	669,1,0;
% 617,	664,7,0;
% 672,	658,1,0;
% 722,	633,1,0;
% 771,	594,1,0;
% 758,	561,1,0;
% 758,	539,7,0;
% 754,	503,1,0;
% 737,	473,1,0;
% 728,	414,1,0;
% 722,	342,1,0;
% 715,	318,7,0;
% 715,	256,7,0;
% 715,	193,7,0;
% 716,	139,7,0;
% 719,	 97,7,0;
% 857,	137,1,0;
% 937,	166,1,0;
% 985,	214,1,0;
% 1009,	278,1,0;
% 1008,	353,1,0;
% 989,	394,1,0;
% 1008,	431,1,0;
% 991,	473,1,0;
% 1010,	510,1,0;
% 1010,	613,1,0;
% 1009,	673,1,0;
% 1009,	733,1,0;
% 1010,	797,1,0;
% 1007,	861,1,0;];
% tP = P(:,1);
% P(:,1) = P(:,2);
% P(:,2) = tP - 540;
% 
P(1,:) =[rand()*length,rand()*width,1,0];
i=2;
while i <= NumofP
    P(i,:) = [rand()*length,rand()*width,1,0];
    pflag = 0;    
    j = 1;
    while j <= i-1
        dist = norm([P(j,1)-P(i,1),P(j,2)-P(i,2)]);
        if(dist < minidistP2P)
            pflag = 1;
            break;
        else            
            j = j+1;            
        end
    end
    if pflag == 0
        i = i+1;
    end
end

%先按y值分上下两组
[SBU,indexBU] = sortrows(P(:,2)); 
numofB = floor(NumofP/2);
if numofB < NumofP/2
    if P(indexBU(numofB+1),2)<width/2
        numofB = numofB +1;
    end
end
%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%
    while (P(indexBU(numofB),2) > width/2+yover) && (numofB>0)
        numofB = numofB - 1;        
    end
    while (P(indexBU(numofB+1),2) < width/2-yover) && (numofB<NumofP)
       numofB = numofB + 1;   
    end
%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%    
for i = 1:numofB
    SetB(i,1:4) = P(indexBU(i),1:4);
end
numofU = NumofP - numofB;
for i = 1:numofU
    SetU(i,1:4) = P(indexBU(i + numofB),1:4);
end

%下组再按x分左右两组
[SB,indexB] = sortrows(SetB(:,1));
% mPLB =0;
% mPRB =0;
% for i = 1:numofB
%     if SetB(i,1)<400
%         mPLB = mPLB+1;
%         PLB(mPLB,:) = SetB(i,:);
%     else
%         mPRB = mPRB+1;
%         PRB(mPRB,:) = SetB(i,:);
%     end
% end
[SB,indexB] = sortrows(SetB(:,1));
mPLB = floor(numofB/2);
if mPLB < numofB/2
    if SetB(indexB(mPLB+1),1)<length/2
        mPLB = mPLB +1;
    end
end
for i = 1:mPLB
    PLB(i,1:4) = SetB(indexB(i),1:4);
end
mPRB = numofB - mPLB;
for i = 1:mPRB
    PRB(i,1:4) = SetB(indexB(i+mPLB),1:4);
end

%上组再按x分左右两组
[SU,indexU] = sortrows(SetU(:,1));
mPLU = floor(numofU/2);
if mPLU < numofU/2
    if SetU(indexU(mPLU+1),1)<length/2
        mPLU = mPLU +1;
    end
end
for i = 1:mPLU
    PLU(i,1:4) = SetU(indexU(i),1:4);
end
mPRU = numofU - mPLU;
for i = 1:mPRU
    PRU(i,1:4) = SetU(indexU(i+mPLU),1:4);
end
