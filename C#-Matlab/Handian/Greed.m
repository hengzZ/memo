function PP = Greed(np,P)
if np < 2
    PP = P;
    return;
end
LB = min(P,[],1);
RU = max(P,[],1);
RB = [RU(1),LB(2)];
LU = [LB(1),RU(2)];

for kkk=0:100  
    newP = P;
    newP(:,5:10) = 0;%5:sort of mini dis, 6,dist to LB, 7,dis to LB / dist to RB, 8,sort of 6; 9,sort of 7, 10:sort of 6+7
    ST = LB;
    for j = 1 : np
        newP(j,7) = abs(LB(1)-newP(j,1)) / (1 + abs(RB(1)-newP(j,1))); 
    end
    [D6,indexD6] = sortrows(newP(:,7));
    for j = 1:np
        newP(indexD6(j),9) = j; 
    end
  
    for i = 1 : np
        for j = 1 : np
            if  newP(j,5) == 0
                newP(j,6) = norm([ST(1)-newP(j,1),ST(2)-newP(j,2)]);
            end
        end
        [D,indexD]   = sortrows(newP(:,6));
        k=1;
        for j = 1 : np
            if  newP(indexD(j),5) == 0
                newP(indexD(j),8) = j+i-k; 
            else
                newP(indexD(j),8) = newP(indexD(j),5);
                k=k+1;
            end        
        end
        for j = 1 : np
            newP(j,10) = newP(j,8)*kkk*0.01 + newP(j,9)*(1-kkk*0.01); 
        end

        [D,indexD]   = sortrows(newP(:,10));
        k = 1;
        while newP(indexD(k),5) > 0
            k = k+1;
        end
        newP(indexD(k),5) = i;

        ST = newP(indexD(k),1:4);
        PPt(kkk+1,i,:)=ST;
    end
end

for kkk=0:100  
    newP = P;
    newP(:,5:10) = 0;%5:sort of mini dis, 6,dist to LB, 7,dis to LB / dist to RB, 8,sort of 6; 9,sort of 7, 10:sort of 6+7
    ST = LB;
    for j = 1 : np
        newP(j,7) = abs(LB(2)-newP(j,2)) / (1 + abs(RU(2)-newP(j,2))); 
    end
    [D6,indexD6] = sortrows(newP(:,7));
    for j = 1:np
        newP(indexD6(j),9) = j; 
    end
  
    for i = 1 : np
        for j = 1 : np
            if  newP(j,5) == 0
                newP(j,6) = norm([ST(1)-newP(j,1),ST(2)-newP(j,2)]);
            end
        end
        [D,indexD]   = sortrows(newP(:,6));
        k=1;
        for j = 1 : np
            if  newP(indexD(j),5) == 0
                newP(indexD(j),8) = j+i-k; 
            else
                newP(indexD(j),8) = newP(indexD(j),5);
                k=k+1;
            end        
        end
        for j = 1 : np
            newP(j,10) = newP(j,8)*kkk*0.01 + newP(j,9)*(1-kkk*0.01); 
        end

        [D,indexD]   = sortrows(newP(:,10));
        k = 1;
        while newP(indexD(k),5) > 0
            k = k+1;
        end
        newP(indexD(k),5) = i;

        ST = newP(indexD(k),1:4);
        PPt(kkk+102,i,:) = ST;
    end    
end

for kkk=1:202
%    PP(:,:) = PPt(kkk,:,:);
%    PP = poly_intersect(np,PP);
%    PPt(kkk,:,:) = PP(:,:);    
%    out = kkk
    LengthAll(kkk) = 0;
    for  i = 2 : np
        LengthAll(kkk) = LengthAll(kkk)+ norm([PPt(kkk,i,1)-PPt(kkk,i-1,1),PPt(kkk,i,2)-PPt(kkk,i-1,2)]);
    end
end
[D,indexD]   = sort(LengthAll);
PP(:,:) = PPt(indexD(1),:,:);
PP = poly_intersect(np,PP);