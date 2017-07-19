function [np1,P1,np2,P2,np3,P3] = ThreeGroup(np,P)
LB = min(P,[],1);
newP = P;

np1 =0;
np2 =0;
np3 =0;
st1 = 0;
st2 = 0;
st3 = 0;

%按指定的分工位
for i = 1: np
    if newP(i,4)==1
        np1=np1+1;
        P1(np1,:) = newP(i,:);
    elseif newP(i,4)==2
        np2=np2+1;
        P2(np2,:) = newP(i,:);
    elseif newP(i,4)==3
        np3=np3+1;
        P3(np3,:) = newP(i,:);
    end
end

%分类型
if np1 > 0
    for i=1:np1
        if P1(i,3)>4
            st1 = 5;
        end
    end
end        
if np2 > 0
    for i=1:np2
        if P2(i,3)>4
            st2 = 5;
        end
    end
end        
if np3 > 0
    for i=1:np3
        if P3(i,3)>4
            st3 = 5;
        end
    end
end    

if st1<5 && st2<5 && st3 <5
    st3 = 5;
end
if st1>4
    for i = 1: np
        if newP(i,3) > 4 && newP(i,4)==0
            np1 = np1+1;
            newP(i,4) = 1;
            P1(np1,:) = newP(i,:);
        end
    end
end
if st2>4
    for i = 1: np
        if newP(i,3) > 4 && newP(i,4)==0
            np2 = np2+1;
            newP(i,4) = 2;
            P2(np2,:) = newP(i,:);
        end
    end
end
if st3>4
    for i = 1: np
        if newP(i,3) > 4 && newP(i,4)==0
            np3 = np3+1;
            newP(i,4) = 3;
            P3(np3,:) = newP(i,:);
        end
    end
end

[Set,indexS] = sortrows(newP(:,2));
for i=1:np
    if np1<ceil(np/3) && newP(indexS(i),4)==0
        np1=np1+1;
        newP(indexS(i),4)=1;
        P1(np1,:)=newP(indexS(i),:);
    end
end
for i=1:np
    if np2<ceil((np-np1)/2) && newP(indexS(i),4)==0
        np2=np2+1;
        newP(indexS(i),4)=2;
        P2(np2,:)=newP(indexS(i),:);
    end
end
for i=1:np
    if np3<(np-np1-np2) && newP(indexS(i),4)==0
        np3=np3+1;
        newP(indexS(i),4)=3;
        P3(np3,:)=newP(indexS(i),:);
    end
end
%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%5   补齐

% 
% [Set,indexS] = sortrows(newP(:,2));
% np1 = ceil(np/3);
% if np1>0
%     for i = 1:np1
%         P1(i,:) = newP(indexS(i),:);
%         P1(i,3) = 1;
%     end
% else
%     P1=[];
% end
% 
% np2 = ceil((np-np1)/2);
% if np2>0
%     for i = 1:np2
%         P2(i,:) = newP(indexS(np1+i),:);
%         P2(i,3) = 2;
%     end
% else
%     P2=[];
% end
% 
% np3 = np-np1-np2;
% if np3>0
%     for i = 1:np3
%         P3(i,:) = newP(indexS(np1+np2+i),:);
%         P3(i,3) = 3;
%     end
% else
%     P3=[];
% end
    