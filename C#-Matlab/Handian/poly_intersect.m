function PP = poly_intersect(np,PP)
% ********************************************************** %
%%% 判断各点按顺序相连的线段是否有交点
%%% poly_x,poly_y 分别为各个点的x,y坐标，均为列向量
% ********************************************************** %

flag=1;
while ( flag == 1 )
    k = 0;
    for i = 1:(np-3)                 %%%第一根线段的起始端点:
        for j = i+2:(np-1)           %%%第二根线段的起始端点:
            X1 = [PP(i,1);PP(i+1,1)];
            Y1 = [PP(i,2);PP(i+1,2)];
            X2 = [PP(j,1);PP(j+1,1)];
            Y2 = [PP(j,2);PP(j+1,2)];
            [intspoint_x,intspoint_y] = polyxpoly(X1,Y1,X2,Y2); % 求两条线段交点的x,y坐标
            if ~isempty(intspoint_x)  %%%若两条线段无交点则跳至下一组线段，若有交点则处理交点的顺序
            %%%若有交点，则将第一根线段的起始端点与第二根线的结束端点交换顺序，并将其中间的焊点逆序排列
                B = [];               %%%B = zeros(j+1-i+1,8);
                B = PP(i+1:j,:);
                B = flipud(B);
                PP(i+1:j,:) = B;
                k=k+1;
            end
        end
    end
    if k==0
        flag = 0;
    end
end